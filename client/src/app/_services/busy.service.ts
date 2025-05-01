import { inject, Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  busyRequestCount = 0;
  private spinnerService = inject(NgxSpinnerService);
  busy():void{
    this.busyRequestCount++;
    this.spinnerService.show(undefined,{
      type: "pacman",
      bdColor: "rgba(0,0,0,0.7)",
      color: "#412669"
    });
  }

  idle():void{
    this.busyRequestCount--;
    if(this.busyRequestCount<=0){
      this.busyRequestCount=0;
      this.spinnerService.hide();
    }
  }

}
