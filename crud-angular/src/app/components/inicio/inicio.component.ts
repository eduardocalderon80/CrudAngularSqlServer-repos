import { Component, OnInit } from '@angular/core';
import { ValueModel } from 'src/app/models/ValueModel';
import { CrudServicioService } from '../../servicio/crud-servicio.service'
import Swal from 'sweetalert2'

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {

  lista: ValueModel[] = [];
  constructor( private servicio: CrudServicioService ) { }

  ngOnInit(): void {
    this.getValueAll();
  }

  getValueAll(){
    this.servicio.getAllValue().subscribe(response => {
      this.lista = response;
    });
  }

  eliminarValor(id: string){
    Swal.fire({
      title: 'Question',
      text: 'Está seguro de eliminar el registro ?',
      icon: 'question',
      showCancelButton: true,
      showCloseButton: true,
      showConfirmButton: true,
      backdrop: false
    }).then(result => {
      if (result.isConfirmed){
        this.servicio.eliminarValor(id).subscribe(response => {
          Swal.fire({
            title: 'Information',
            text: 'Se eliminó correctamente...!',
            icon: 'success'
          }).then(result => {
            this.getValueAll();
          });
        });
      }
    });
  }
}
