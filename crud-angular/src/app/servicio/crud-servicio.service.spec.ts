import { TestBed } from '@angular/core/testing';

import { CrudServicioService } from './crud-servicio.service';

describe('CrudServicioService', () => {
  let service: CrudServicioService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CrudServicioService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
