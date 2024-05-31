import { Component , OnInit,ViewChild} from '@angular/core';
import { StudentService } from './student.service';
import { Student } from '../Models/ui-models/student.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {
  students:Student[] =[];
  displayedColumns: string[] = ['firstName', 'lastName', 'dateOfBirth', 'email', 'mobile', 'gender','edit'];
  dataSource:MatTableDataSource<Student> = new MatTableDataSource<Student>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  filterSting=""

  constructor(private studentService:StudentService) {
    
  }
  ngOnInit(): void {
    
    this.studentService.getStudents().subscribe(
      
      (succes) =>{
        this.students=succes;
        this.dataSource = new MatTableDataSource<Student>(this.students);
        this.dataSource.paginator = this.paginator
        this.dataSource.sort = this.sort;

      },
      (err) =>{

      }
    )
  }
  filteStundets(){
    this.dataSource.filter = this.filterSting.trim().toLocaleLowerCase();
  }

}
