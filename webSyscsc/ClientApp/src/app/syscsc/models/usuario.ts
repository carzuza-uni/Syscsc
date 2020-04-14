export class Usuario {
    tipoUsuario: number;
    primerNombre: string;
    segundoNombre: string;
    primerApellido: string;
    segundoApellido: string;
    numeroCedula: string;
    usuarioI: string;
    contrasena: string;
    confirmarContrasena: string;
    telefono: string;
    email: string;

    tipoUsuarioNombre(){
        let tipo = [];
        tipo[1] = 'Administrador';
        tipo[2] = 'Técnico';
        return tipo[this.tipoUsuario];
    }

    validarContrasena(){
        if(this.contrasena == this.confirmarContrasena){
            return true;
        }
        return false;
    }
}
