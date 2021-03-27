import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { NgForm, NgModelGroup } from '@angular/forms';
import { CrudServicioService } from '../../servicio/crud-servicio.service';
import { ValueModel } from '../../models/ValueModel';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit {
  id: string = '';
  valor = new ValueModel();
  constructor( private ruta: ActivatedRoute,
                private servicio: CrudServicioService) { 
                  
    this.id = ruta.snapshot.paramMap.get('id');
    console.log('mi id', this.id);
  }

  ngOnInit(): void {
    if (this.id !== 'nuevo'){
      this.getValor();
    } else {
      this.valor.id = 0
    }
    
  }

  getValor(){
      this.servicio.getValorId(this.id).subscribe(response => {
        this.valor = response;
      });
  }

  grabar(form: NgForm){
    if (form.invalid){
      return;
    }
    
    if (this.id !== 'nuevo'){
      this.servicio.actualizarValor(this.valor).subscribe(response => {
        Swal.fire({
          title: 'Informacion',
          text: 'Se actualizó con éxito...!',
          icon: 'success'
        }).then(result => {
          window.location.href = '/inicio';
        });
      });
    } else {
      this.servicio.nuevoValor(this.valor).subscribe(response => {
        Swal.fire({
          title: 'Informacion',
          text: 'Se insertó con éxito...!',
          icon: 'success'
        }).then(result => {
          window.location.href = '/inicio';
        });
      });
    }
  }

  
}
