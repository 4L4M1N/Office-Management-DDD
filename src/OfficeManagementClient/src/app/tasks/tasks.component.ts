import { Component, OnInit } from '@angular/core';
import { TestService } from '../services/test.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  a: any;
  constructor(private test: TestService) { }

  ngOnInit() {
    //this.a = this.test.GetTest();
    this.test.GetTest().subscribe(data => {
      this.a = data;
    });
    console.log(this.a);
  }

}
