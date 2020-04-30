import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Usuario } from '../models/usuario';

@Component({
  selector: 'app-usuario-consulta',
  templateUrl: './usuario-consulta.component.html',
  styleUrls: ['./usuario-consulta.component.css']
})
export class UsuarioConsultaComponent implements OnInit {
  usuarios: Usuario[];
  u: Usuario;
  searchText:string;

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit() {
    this.usuarioService.get().subscribe(result => {
      console.log('result',result);
      let datos = [];
      for (let i = 0; i < result.length; i++) {
        const element = result[i];
        this.u = new Usuario();
        this.u.tipoUsuario = element.tipoUsuario;
        this.u.primerNombre = element.primerNombre;
        this.u.segundoNombre = element.segundoNombre;
        this.u.primerApellido = element.primerApellido;
        this.u.segundoApellido = element.segundoApellido;
        this.u.numeroCedula = element.numeroCedula;
        this.u.usuarioI = element.usuarioI;
        this.u.email = element.email;
        this.u.telefono = element.telefono;
        this.u.setTipoUsuarioNombre();
        this.u.setNombreCompleto();

        //console.log('u', this.u);
        let item = JSON.stringify(this.u);
        //console.log('item', item);
        let item2 = JSON.parse(item);
        console.log('item2', item2);
        datos.push(item2);
      }
      console.log('datos', datos);
      this.usuarios = datos;
    }) 
  }

}
