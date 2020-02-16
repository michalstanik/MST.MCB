import { Injectable } from '@angular/core';

declare let toastr: any;

@Injectable()
export class ToastrService {
  constructor() {
    toastr.options = {
      closeButton: false,
      newestOnTop: false,
      progressBar: true,
      positionClass: 'toast-top-right',
      showDuration: '300',
      hideDuration: '1000',
      timeOut: '5000'
    };
  }

  success(message: string, title?: string) {
    toastr.success(message, title);
  }

  info(message: string, title?: string) {
    toastr.info(message, title);
  }

  warning(message: string, title?: string) {
    toastr.warning(message, title);
  }

  error(message: string, title?: string) {
    toastr.error(message, title);
  }
}
