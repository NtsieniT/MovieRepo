import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { IMovies } from './models/Movies';
import { omit } from 'lodash';

@Injectable({
  providedIn: 'root'
})
export class MovieService {




constructor(private http: HttpClient) { }


  baseUrl = 'https://localhost:5001/api/';
  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };




  //#region FORMS INITIALIZE, POPULATE AND SET
  movie: IMovies[] = [];

  movieForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    name: new FormControl('', Validators.required),   
    rating: new FormControl('', Validators.required), 
    typeId: new FormControl()

  });
  //#endregion


//#region  HTTPServices

getMovies(): Observable<IMovies[]> {
  return this.http.get<IMovies[]>(this.baseUrl + 'Movie/ListMovies');
}

createMovie(movie: IMovies): Observable<IMovies> {
  return this.http.post<IMovies>(this.baseUrl + 'Movie/AddMovie', movie, this.httpOptions);
}
updateMovie(movie: IMovies): Observable<IMovies> {
  return this.http.put<IMovies>(this.baseUrl + 'Movie/UpdateMovie', movie, this.httpOptions);
}

deleteMovie(movieId: number): Observable<number> {
  return this.http.delete<number>(this.baseUrl + 'Movie/DeleteMovie/' + movieId, this.httpOptions);
}

  //#endregion

  initializeForm() {
    this.movieForm.setValue({
      id: 0,
      name: '', 
      rating: 0,     
      typeId: null
    });
    
  }

  populateMovie(movie: IMovies) {
    this.movieForm.setValue(omit(movie, 'type'));
  }

}
