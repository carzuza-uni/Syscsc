import { Pipe, PipeTransform } from '@angular/core';
import { Usuario } from '../syscsc/models/usuario';

@Pipe({
  name: 'filtroUsuario'
})
export class FiltroUsuarioPipe implements PipeTransform {

  transform(usuario: Usuario[], searchText: string): any {
    if(searchText == null){
      return usuario;
    }
    return usuario.filter(u => u.nombreCompleto.toLowerCase().indexOf(searchText.toLowerCase()) !== -1 || u.numeroCedula.toLowerCase().indexOf(searchText.toLowerCase()) !== -1 );
  }

}
