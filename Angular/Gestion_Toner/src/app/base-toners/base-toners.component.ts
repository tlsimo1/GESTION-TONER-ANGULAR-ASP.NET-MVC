import { Component, OnInit,ViewChild } from '@angular/core';
import { BaseTonerService } from '../shared/base-toner.service';
import {MatDialog,MatDialogConfig} from '@angular/material/dialog';
import { TonerComponent } from './toner/toner.component';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';

@Component({
  selector: 'app-base-toners',
  templateUrl: './base-toners.component.html',
  styleUrls: ['./base-toners.component.css']
})
export class BaseTonersComponent implements OnInit{

  displayedColumns: string[] = ['reference', 'description','action'];
  dataSource!: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  constructor(private _dialog:MatDialog,private service :BaseTonerService)
  {
  }
  ngOnInit(): void {
    this.GetAllTonnerList();
  }
  GetAllTonnerList()
  {
    this.service.GetAllTonnerList().subscribe({
      next:(res)=>{
        this.dataSource=new MatTableDataSource(res);
        this.dataSource.sort=this.sort;
        this.dataSource.paginator=this.paginator;
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }
  DeleteTonner(reference:string)
  {
    if(confirm('Are you sure to delete this record'))
    {
      this.service.DeleteToner(reference).subscribe({
        next:(res)=>
        {
          alert('tonner deleted');
          this.GetAllTonnerList();
        },
        error:(err)=>{
            console.log(err)
        }
      })
    }
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  OpenAddEdirToner()
  {
    this.service.initializeFormGroup();
    const dialogConfig=new MatDialogConfig();
    dialogConfig.disableClose=true;
    dialogConfig.autoFocus=true;
    dialogConfig.width="40%";
    dialogConfig.height="70%";
    const dialogRef=this._dialog.open(TonerComponent, dialogConfig)
    dialogRef.afterClosed().subscribe({
      next:(val)=>{
        this.GetAllTonnerList();
      }
    })
  }
  OpenEditFomr(data:any)
  {
    this.service.populateForm(data);
    const dialogConfig=new MatDialogConfig();
    dialogConfig.disableClose=true;
    dialogConfig.autoFocus=true;
    dialogConfig.width="40%";
    dialogConfig.height="70%";
    const dialogRef=this._dialog.open(TonerComponent,dialogConfig);
    dialogRef.afterClosed().subscribe({
      next:(res)=>
      {
        this.GetAllTonnerList();
      },
      error:(error)=>{
        alert(error)
      }
    })
  }
}
