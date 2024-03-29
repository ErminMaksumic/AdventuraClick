import { Component } from '@angular/core';
import { Rating } from 'src/app/models/rating.model';
import { RatingService } from 'src/app/services/rating.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-ratings',
  templateUrl: './ratings.component.html',
  styleUrls: ['./ratings.component.css'],
})
export class RatingsComponent {
  ratings: Rating[] = [];
  searchQuery: string = '';
  constructor(
    private ratingService: RatingService,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.userService.changeActiveMenu('Ratings');
    this.loadRatings();
  }

  loadRatings(search: string = '') {
    this.ratingService
      .getAll({
        IncludeUser: true,
        IncludeTravel: true,
        name: search,
        username: search,
      })
      .subscribe({
        next: (result: Rating[]) => {
          this.ratings = result;
        },
        error: (error: any) => {
          console.log('error', error);
        },
      });
  }

  search(input: string) {
    this.loadRatings(input);
  }
}
