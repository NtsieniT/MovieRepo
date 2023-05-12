import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';

import { IMovies} from 'src/app/shared/models/Movies';
import { MovieService } from '../../shared/movie.service';
import { ToastrService } from 'ngx-toastr';

import { MovieComponent } from '../movie/movie.component';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss']
})
export class MovieListComponent implements OnInit {

  constructor(
    private movieService: MovieService,
    private dialog: MatDialog,
    private toastr: ToastrService
    ) { }


    movieData: IMovies[] = [];
    dataSource: MatTableDataSource<any>;

    displayedColumns: string[] = ['Name', 'Rating', 'movie Type', 'Action'];


  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  searchKey: string;

  dialogConfig = new MatDialogConfig();

  ngOnInit(){
    this.listMovies();
  }

  onSearchClear() {
    this.searchKey = '';
    this.applyFilter();
  }

  applyFilter() {

    this.dataSource.filter = this.searchKey.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


  listMovies() {
    this.movieService.getMovies().subscribe(response => {
      this.movieData = response;
      this.dataSource = new MatTableDataSource(this.movieData);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    },
    error => {
      console.log(error);
    });

  }


  private refreshTable() {
    this.paginator._changePageSize(this.paginator.pageSize);
  }

  onCreate(){
    this.movieService.initializeForm();
    this.dialogConfig.disableClose = true;
    this.dialogConfig.autoFocus = true;
    this.dialogConfig.width = '45%';
    this.dialog.open(MovieComponent, this.dialogConfig);
    this.RefreshListOnDialogClose();
  }

  viewMovieInfo(row: any){
    this.movieService.populateMovie(row);
    this.dialogConfig.disableClose = true;
    this.dialogConfig.width = '45%';
    this.dialog.open(MovieComponent, this.dialogConfig);
    this.RefreshListOnDialogClose();

  }

  deleteMovieInfo(id: number){
    if (confirm('Are you sure ?')) {
    this.movieService.deleteMovie(id).subscribe(response => {
      this.toastr.warning('Movie successfully deleted!');
      this.listMovies();
      this.refreshTable();
    }, error => {
      console.log(error.message);
    });
    }

  }
  // Configure dialog box here
  dialogConfigs(dialogConfigs: MatDialogConfig){
    dialogConfigs.disableClose = true;
    dialogConfigs.autoFocus = true;
    dialogConfigs.width = '45%';
    this.dialog.open(MovieComponent, this.dialogConfig);
  }



  RefreshListOnDialogClose(){
    this.dialog.afterAllClosed.subscribe(() =>{
      this.listMovies();
      this.refreshTable();
    })
  }



}
