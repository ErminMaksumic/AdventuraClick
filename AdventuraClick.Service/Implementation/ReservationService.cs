﻿using AdventuraClick.Model.Requests;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventuraClick.Service.Implementation
{
    public class ReservationService : CRUDService<Model.Reservation, ReservationSearchObject, Database.Reservation, ReservationInsertRequest,
        ReservationUpdateRequest>, IReservationService
    {
        public ReservationService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        { }

        public override IQueryable<Reservation> AddInclude(IQueryable<Reservation> query, ReservationSearchObject search = null)
        {
            var includedQuery = base.AddInclude(query, search);

            if (search.IncludeUser)
            {
                includedQuery = includedQuery.Include("User");
            }
            if (search.IncludeAdditionalServices)
            {
                includedQuery = includedQuery.Include(x => x.AdditionalServicesReservations).ThenInclude(x => x.AdditionalService);
            }
            if (search.IncludeTravel)
            {
                includedQuery = includedQuery.Include(x => x.Travel)
                                             .ThenInclude(x => x.TravelType)
                                             .Include(x => x.Travel)
                                             .ThenInclude(x => x.IncludedItemTravels).ThenInclude(x=> x.IncludedItem);
            }
            if (search.IncludePayment)
            {
                includedQuery = includedQuery.Include("Payment");
            }
            if (search.IncludeTravelInformation)
            {
                includedQuery = includedQuery.Include("TravelInformation");
            }

            return includedQuery;
        }

        public override IQueryable<Reservation> AddFilter(IQueryable<Reservation> query, ReservationSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);

            if (!string.IsNullOrEmpty(search.Name))
            {
                filteredQuery = filteredQuery.Where(x => x.Travel.Name.StartsWith(search.Name) || x.User.Username.StartsWith(search.Name));
            }
            if (search.UserId > 0)
            {
                filteredQuery = filteredQuery.Where(x => x.UserId == search.UserId);
            }
            return filteredQuery;
        }

        public override Model.Reservation Insert(ReservationInsertRequest request)
        {
            var reservation = _mapper.Map<Reservation>(request);
            _context.Reservations.Add(reservation);
            _context.SaveChanges();


            foreach (var reservationAdditionalService in request.AdditionalServices)
            {
                AdditionalServiceReservation reservationAdditionalServiceObject = new AdditionalServiceReservation();
                reservationAdditionalServiceObject.AdditionalServiceId = reservationAdditionalService;
                reservationAdditionalServiceObject.ReservationId = reservation.ReservationId;
                _context.AdditionalServiceReservations.Add(reservationAdditionalServiceObject);
                _context.SaveChanges();
            }

            return _mapper.Map<Model.Reservation>(reservation);
        }

        public Model.Reservation ChangeStatus(int id, ChangeReservationStatus request)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation != null)
            {
                reservation.Status = request.Status;
                _context.SaveChanges();
            }
            return _mapper.Map<Model.Reservation>(reservation);
        }
    }
}
