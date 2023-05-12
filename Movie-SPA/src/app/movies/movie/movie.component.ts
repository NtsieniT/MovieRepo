import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { IType } from 'src/app/shared/models/Types';
import { TypesService } from 'src/app/shared/types.service';
import { MovieService } from '../../shared/movie.service';
import { MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.scss']
})
export class MovieComponent implements OnInit {

  types: IType[];

  constructor(
    private fb: FormBuilder,
    public movieService: MovieService,
    private typesService: TypesService,
    public dialogRef: MatDialogRef<MovieComponent>,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.loadMovieTypes();
  }

  //#region SERVICES
  loadMovieTypes(){
    this.typesService.getTypes().subscribe(response => {
      this.types = response;
    }, error => {
      console.log(error);
    });
  }

//#endregion



//#region DIALOG BUTTON FUNCTIONS
SaveMovie(): void{

  const id = this.movieService.movieForm.value.id;
  if (!id || id === 0){
    this.movieService.createMovie(this.movieService.movieForm.value).subscribe(response => {
      this.toastr.success('Customer added successfully!');
    }, error => {
      this.toastr.error(error.message);
      console.log(error.message);
    }
    );
    this.movieService.getMovies().subscribe();

  }
  else {
    this.movieService.updateMovie(this.movieService.movieForm.value).subscribe(response => {
      this.toastr.success('Customer updated successfully');

       }, error => {
        this.toastr.error(error.message);
        console.log(error.message);
        }
    );
  }

  this.movieService.movieForm.reset();
  this.movieService.initializeForm();
  this.closeDialog();
}

closeDialog(){
  this.movieService.movieForm.reset();
  this.movieService.initializeForm();
  this.dialogRef.close();

}
//#endregion

}
