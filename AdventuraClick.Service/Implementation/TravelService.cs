using AdventuraClick.Model;
using AdventuraClick.Model.SearchObjects;
using AdventuraClick.Service.Database;
using AdventuraClick.Service.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Travel = AdventuraClick.Service.Database.Travel;

namespace AdventuraClick.Service.Implementation
{
    public class TravelService : CRUDService<Model.Travel, TravelSearchObject, Database.Travel, TravelInsertRequest,
        TravelUpdateRequest>, ITravelService
    {
        public TravelService(AdventuraClickInitContext context, IMapper mapper) : base(context, mapper)
        { }

        public override IQueryable<Travel> AddInclude(IQueryable<Travel> query, TravelSearchObject searchObject = null)
        {
            var includedQuery = base.AddInclude(query, searchObject);

            if (searchObject.IncludeLocation)
            {
                includedQuery = includedQuery.Include("Location");
            }
            if (searchObject.IncludeTravelType)
            {
                includedQuery = includedQuery.Include("TravelType");
            }
            if (searchObject.IncludeTravelInformation)
            {
                includedQuery = includedQuery.Include("TravelInformations");
            }

            return includedQuery;
        }

        public override IQueryable<Travel> AddFilter(IQueryable<Travel> query, TravelSearchObject search = null)
        {
            var filteredQuery = base.AddFilter(query, search);
            var price = search.Price;

            if (search.Price > 0)
            {
                filteredQuery = filteredQuery.Where(x => x.Price <= price);
            }
            if (!string.IsNullOrEmpty(search.Name))
            {
                filteredQuery = filteredQuery.Where(x => x.Name.ToLower().StartsWith(search.Name.ToLower()));
            }
          
            if (search.TravelTypeId > 0)
            {
                filteredQuery = filteredQuery.Where(x => x.TravelTypeId == search.TravelTypeId);
            }
            return filteredQuery;
        }

        public override Model.Travel GetById(int id)
        {
            var entity = _context.Travels.
                Include("Location").
                Include("TravelType").
                Include(x => x.TravelInformations).
                Include(x => x.IncludedItemTravels).
                ThenInclude(x => x.IncludedItem).
                FirstOrDefault(x => x.TravelId == id);

            return _mapper.Map<Model.Travel>(entity);
        }

        public override void BeforeDelete(Travel entity)
        {
            var travelInormation = _context.TravelInformations.Include("Travel").Where(x => x.TravelId == entity.TravelId).ToList(); 
            var reservations = _context.Reservations.Include("TravelInformation").Where(x => x.TravelId == entity.TravelId).ToList();
            var payments = _context.Payments.Include("Travel").Where(x => x.TravelId == entity.TravelId).ToList();
            var ratings = _context.Ratings.Include("Travel").Where(x => x.TravelId == entity.TravelId).ToList();
            var includeItemTravels = _context.IncludedItemTravels.Include("Travel").Where(x => x.TravelId == entity.TravelId).ToList();
            foreach (var item in includeItemTravels)
            {
                _context.IncludedItemTravels.RemoveRange(item);
            }
            _context.TravelInformations.RemoveRange(travelInormation);
            _context.Payments.RemoveRange(payments);
            _context.Ratings.RemoveRange(ratings);
            _context.SaveChanges();
        }

        public override Model.Travel Insert(TravelInsertRequest request)
        {
            byte[] imageBytes = Convert.FromBase64String(request.ImageString);
            request.Image = imageBytes;
            return base.Insert(request);
        }
    }
}