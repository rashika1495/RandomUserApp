import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public randomUser: RandomUser | undefined;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Basic ' + btoa('randomuser:Password@123')
      })
    };

    http.get<RandomUser>('https://localhost:7226/user/randomuser', httpOptions).subscribe(result => {
      this.randomUser = result;
    }, error => console.error(error));
  }
}

export interface RandomUser {
  results: Result[]
  info: Info
}

export interface Result {
  gender: string
  name: Name
  location: Location
  email: string
  login: Login
  dob: Dob
  registered: Registered
  phone: string
  cell: string
  id: Id
  picture: Picture
  nat: string
}

export interface Name {
  title: string
  first: string
  last: string
}

export interface Location {
  street: Street
  city: string
  state: string
  country: string
  postcode: string
  coordinates: Coordinates
  timezone: Timezone
}

export interface Street {
  number: number
  name: string
}

export interface Coordinates {
  latitude: string
  longitude: string
}

export interface Timezone {
  offset: string
  description: string
}

export interface Login {
  uuid: string
  username: string
  password: string
  salt: string
  md5: string
  sha1: string
  sha256: string
}

export interface Dob {
  date: string
  age: number
}

export interface Registered {
  date: string
  age: number
}

export interface Id {
  name: string
  value: string
}

export interface Picture {
  large: string
  medium: string
  thumbnail: string
}

export interface Info {
  seed: string
  results: number
  page: number
  version: string
}
