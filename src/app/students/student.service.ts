import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../Models/apimodels/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private baseApiUrl='https://localhost:44381';
  constructor(private httpClient:HttpClient) { }

  getStudents():Observable<Student[]>{
    return this.httpClient.get<Student[]>(this.baseApiUrl+'/Students');
  }
  getStudent(studentId:string |null):Observable<Student>{
    return this.httpClient.get<Student>(this.baseApiUrl+'/students/'+studentId);
  }
}
