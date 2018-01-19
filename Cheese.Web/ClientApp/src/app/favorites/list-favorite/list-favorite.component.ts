import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Favorite, User, Store, Location } from '../model';

@Component({
  selector: 'app-list-favorite',
  templateUrl: './list-favorite.component.html',
  styleUrls: ['./list-favorite.component.css']
})
export class ListFavoriteComponent implements OnInit {
  baseUrl: string;
  favorites: Favorite[];

  constructor(private http: HttpClient, @Inject('BASE_URL') url: string) {
    this.baseUrl = url;
  }

  ngOnInit() {
  }

  getFavorites() {
    let userId = "6771e12b-268e-4a1c-90c3-7cf75d91ae50";

    this.http.get(this.baseUrl + 'api/favorites/' + userId).subscribe((result: Favorite[]) => {
      this.favorites = result;
    }, error => console.error(error));

  }

}
