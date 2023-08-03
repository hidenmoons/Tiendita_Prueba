import { Component, OnInit } from '@angular/core';
import { ApiServiceService } from '../services/api-service.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
@Component({
  selector: 'app-registro-login',
  templateUrl: './registro-login.component.html',
  styleUrls: ['./registro-login.component.css']
})
export class RegistroLoginComponent implements OnInit {
  isRegisterForm: boolean = true;
  registro: {
    username: string;
    passwo: string;
    email: string;
    addres: string;
    roles: string;
  } = {
    username: '',
    passwo: '',
    email: '',
    addres: '',
    roles: ''
  };

  login: {
    email: string;
    password: string;
  }={
    email:'',
    password: '',
}
  constructor(private userservice:ApiServiceService ,private router: Router) { }

  ngOnInit(): void {
  }
 registrarUsuario() {
    // Aquí puedes implementar la lógica para registrar al usuario utilizando un servicio
    console.log('Formulario de registro enviado', this.registro);
  }

  activeTab() {
    this.isRegisterForm = !this.isRegisterForm;
  }

  onRegisterSubmit() {

    console.log(this.registro)
    this.userservice.register(this.registro).subscribe(data=>{
      console.log(data)
    })
    this.activeTab();
  }

  onLoginSubmit() {
     
    this.userservice.removeToken();
    
    this.userservice.Login(this.login).subscribe(data => {
      this.userservice.saveToken(data.token);
      this.userservice.saveUser(data.user);
    });

    window.location.href = '/Catalogo';
  }
}
