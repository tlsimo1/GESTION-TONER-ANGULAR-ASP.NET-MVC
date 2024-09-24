import { Injectable } from '@angular/core';
import { FormGroup,FormControl, Validators } from '@angular/forms';
import { HttpClient } from "@angular/common/http";
//import { environment } from 'src/environments/environment';
import { BaseToner } from '../base-toner.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class BaseTonerService {
  url:string='localhost:8084/api/BaseToner/'

  list:BaseToner[]=[]
  constructor(public http:HttpClient) { }

  form:FormGroup=new FormGroup({
    idTonner: new FormControl(0),
    reference: new FormControl('',Validators.required),
    description: new FormControl('',Validators.required),
  })
  initializeFormGroup()
  {
    this.form.setValue({
      idTonner:0,
      reference:'',
      description:''
    });
  }
  GetAllTonnerList():Observable<any>
  {
    return this.http.get('https://localhost:7197/api/BaseToner/GetAllToner');
  }
  RefreshList()
  {
    this.http.get(this.url).subscribe({
      next:res=>{
          this.list=res as BaseToner[]
      },
      error:err=>{console.log(err)}
    })
  }
  PostBaseToner(formData:any)
  {
    return this.http.post('https://localhost:7197/api/BaseToner/CreateToner',formData);
  }
  PutBaseToner(formData:any)
  {
    debugger
    return this.http.put(`https://localhost:7197/api/BaseToner/UpdateToner`,formData)
  }
  DeleteToner(reference:string)
  {
    return this.http.delete(`https://localhost:7197/api/BaseToner/RemoveToner?Reference=${reference}`)
  }

  populateForm(data:any)
  {
    this.form.patchValue(data)
  }
}
