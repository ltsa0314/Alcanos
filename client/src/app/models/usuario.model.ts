export class Usuario {
  UsuarioId: number;
  Nombre: string;
  Contrasena: string;
  Correo: string;
  Fecha: Date;

  constructor() {
    this.UsuarioId = 0;
    this.Nombre = '';
    this.Contrasena = '';
    this.Correo = '';
    this.Fecha = new Date();
  }
}
