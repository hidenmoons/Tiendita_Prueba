import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '../services/api-service.service';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  currentUser: any;

  constructor(private apiService: ApiServiceService) { }

  ngOnInit(): void {
    this.currentUser = this.apiService.getCurrentUser();
  }

  logout(): void {
    this.currentUser= this.apiService.removeToken();
    this.apiService.removeusers();
  }
}
