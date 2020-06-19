import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class TestService {
  baseURL = 'https://localhost:6001/api/test/';
constructor(private http: HttpClient) { }

GetTest() {
  console.log('hadn');
  return this.http.get(this.baseURL + 'allboard',{responseType: 'text'});
}

}
