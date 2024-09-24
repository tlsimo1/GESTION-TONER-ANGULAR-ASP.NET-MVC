
import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BaseToner } from 'src/app/base-toner.model';
import { BaseTonerService } from 'src/app/shared/base-toner.service';


@Component({
  selector: 'app-toner',
  templateUrl: './toner.component.html',
  styleUrls: ['./toner.component.css']
})
export class TonerComponent implements OnInit {

  constructor(public service:BaseTonerService,private dialogref:MatDialogRef<TonerComponent>,
              @Inject(MAT_DIALOG_DATA) public data:any)
    {
    }
    ngOnInit()
    {
      this.service.form.patchValue(this.data);
    }
    onClear()
    {
      this.service.form.reset();
      this.service.initializeFormGroup();
    }
    onSubmit(){
      if(this.service.form.valid){
        if(!this.service.form.get('idTonner')?.value)
        {
          this.service.PostBaseToner(this.service.form.value).subscribe({
            next:res=>
            {
              alert("tonner Add Successfuly");
              this.dialogref.close(true)
            },
            error: err => { console.log(err) }
        })
        }
        else{
          console.log('update');
          this.service.PutBaseToner(this.service.form.value).
          subscribe({
            next:res=>
            {
              alert('Toner Updated Successfuly');
              this.dialogref.close();
            }
          })
        }
      }
    }
    onClose() {
      this.service.form.reset();
      this.service.initializeFormGroup();
      this.dialogref.close();
    }
}
