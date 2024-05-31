import { Component,OnInit } from '@angular/core';
import { StudentService } from '../student.service';
import { ActivatedRoute, ActivationEnd } from '@angular/router';
import { Student } from 'src/app/Models/ui-models/student.model';

import { Gender } from 'src/app/Models/ui-models/gender.model';
import { GenderService } from '../services/gender.service';

@Component({
  selector: 'app-view-student',
  templateUrl: './view-student.component.html',
  styleUrls: ['./view-student.component.css']
})
export class ViewStudentComponent implements OnInit {
  studentId:string|null | undefined;
  genderList:Gender[]=[];
  student:Student={
    id:'',
    firstName:'',
    lastName:'',
    dateOfBirth:'',
    email:'',
    mobile:0,
    genderId:'',
    profileImageUrl:'',
    gender:{
      id:'',
      description:'',
    },
    address:{
      id:'',
      physicalAddress:'',
      postalAddress:''
    }


  };
  

  constructor(private readonly studentService:StudentService,
    private readonly genderService:GenderService,
    private readonly route:ActivatedRoute
    ) {
    
  }
  
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params) => {
        this.studentId =  params.get('id')
        this.studentService.getStudent(this.studentId).subscribe(
          (success) => {
            this.student=success;
          },
          (err) =>{
            
          }
        )
        this.genderService.getGenderList().subscribe(
          (success) => {
            this.genderList=success;
          },
          (err) =>{
            
          }
        )
        

      }

     
    )
  }
}
