import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Usuario } from '../models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-usuario-registro',
  templateUrl: './usuario-registro.component.html',
  styleUrls: ['./usuario-registro.component.css']
})
export class UsuarioRegistroComponent implements OnInit {
  usuario: Usuario;
  numeroCedula;
  constructor(private route: ActivatedRoute, private usuarioService: UsuarioService) { 
    this.numeroCedula = route.snapshot.params['id'];
    console.log('numeroCedula', this.numeroCedula);
    if(this.numeroCedula){
      //consultar
    }
  }

  ngOnInit() {
    this.usuario = new Usuario();
  }

  add(){
    if(!this.usuario.validarContrasena()){
      alert('La contraseña no coincide');
      return false;
    }
    this.usuario.tipoUsuario = Number(this.usuario.tipoUsuario);
    this.usuario.numeroCedula = ''+this.usuario.numeroCedula;
    this.usuario.telefono = ''+this.usuario.telefono;
    this.usuarioService.post(this.usuario).subscribe(p => {
      if (!p) {
        this.usuario.tipoUsuario = null;
        this.usuario.primerNombre = '';
        this.usuario.segundoNombre = '';
        this.usuario.primerApellido = '';
        this.usuario.segundoApellido = '';
        this.usuario.numeroCedula = '';
        this.usuario.usuarioI = '';
        this.usuario.contrasena = '';
        this.usuario.confirmarContrasena = '';
        this.usuario.email = '';
        this.usuario.telefono = '';
        alert('Registro realizado con exito!');
      }
    });
  }

}
