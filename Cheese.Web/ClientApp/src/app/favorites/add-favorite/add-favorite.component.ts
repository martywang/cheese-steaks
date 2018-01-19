import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Favorite, User, Store, Location } from '../model';

@Component({
  selector: 'app-add-favorite',
  templateUrl: './add-favorite.component.html',
  styleUrls: ['./add-favorite.component.css']
})
export class AddFavoriteComponent implements OnInit {
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') url: string) {
    this.baseUrl = url;
  }

  ngOnInit() {
  }

  addFavorite() {
    let fav = new Favorite();
    fav.rating = 2;
    fav.review = "test";
    fav.user = new User();
    fav.user.id = "6771e12b-268e-4a1c-90c3-7cf75d91ae50";
    fav.user.firstName = "test";
    fav.user.lastName = "last";
    fav.store = new Store();
    fav.store.name = "moochies";
    fav.store.location = new Location();
    fav.store.location.addressLine1 = "380 N 850 E";
    fav.store.location.locality = "Lehi";
    fav.store.location.region = "UT";
    fav.store.location.postalCode = "84043";
    fav.store.location.country = "US";
    fav.store.location.latitude = 40.392156;
    fav.store.location.longitude = -111.836460;

    this.http.post('favorites', fav).subscribe(result => {
      console.log('added');
    }, error => console.error(error));
  }

}
