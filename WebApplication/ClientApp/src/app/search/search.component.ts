import {Component, Inject} from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {el} from "@angular/platform-browser/testing/src/browser_util";

@Component({
  selector: 'search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {
  public phones: string[];
  private _http: HttpClient;
  private _baseUrl: string;
  public searchString: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._http = http;
    this._baseUrl = baseUrl;
  }

  find(searchString){
    if (searchString == '') {
      this.phones = [];
      return;
    }

    this._http.get<string[]>(
      this._baseUrl + 'api/Search/Find',
      { params: new HttpParams().set('searchString', searchString) })
        .subscribe(result => {
          if(result.length > 0) {
            this.phones = result;
          } else {
            this.phones = ['Not found.'];
          }
        }, error => {
          console.error(error);
        });
  }
}
