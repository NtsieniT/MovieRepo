import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { IType } from './models/Types';

@Injectable({
  providedIn: 'root'
})
export class TypesService {

  baseUrl = 'https://localhost:5001/api/';
  types: IType[] = [];

constructor(private http: HttpClient) { }

getTypes() {
  if (this.types.length > 0) {
    return of(this.types);
  }
  return this.http.get<IType[]>(this.baseUrl + 'Types/GetMovieTypes').pipe(
    map((response: IType[]) => {
      this.types = response;
      return response;
    })
  );
}

}
