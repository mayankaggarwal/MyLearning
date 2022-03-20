import { EmCustomEvents } from './../../constants/em-custom-events';
import { DhMessageType } from './../../enum/dh-message-type.enum';
import { DhMessage } from './model/dh-message.model';
import { Component, OnInit, Input, Output, EventEmitter, ElementRef, HostListener } from '@angular/core';
import { DhMessagePageModel } from './model/dh-message.page.model';

@Component({
  selector: 'app-dh-message',
  templateUrl: './dh-message.component.html',
  styleUrls: ['./dh-message.component.css']
})
export class DhMessageComponent implements OnInit {

  // tslint:disable-next-line: no-input-rename
  @Input('option') model: DhMessage;
  // tslint:disable-next-line: no-output-rename
  @Output('dh-close') close = new EventEmitter<any>();

  messageType = DhMessageType;
  public pageModel: DhMessagePageModel = new DhMessagePageModel();

  constructor(private myElement: ElementRef) { }

  ngOnInit() {
    console.log(this.model);
    if (this.model) {
      switch (this.model.type) {
        case DhMessageType.DhFailure:
        case DhMessageType.DhInfo:
          if (typeof this.model.dhDismissible === 'undefined') {
            this.model.dhDismissible = true;
          }
          break;
        case DhMessageType.DhForbidden:
          if (!(this.model.description && this.model.description.length > 0)) {
            this.model.title = this.pageModel.dhForbidden;
          }
          break;
          case DhMessageType.DhLoading:
            if (!(this.model.description && this.model.description.length > 0)) {
              this.model.title = this.pageModel.dhLoading;
            }
            break;
      }
    }
  }

  @HostListener(EmCustomEvents.evtDocumentReloadPageModel)
  public reloadPageModel(data?: DhMessagePageModel): void {
    if (data) { this.pageModel = data; } else {
      // this.translationService.populateTranslation(ComponentIdentifier.sharedDhMessage, this.pageModel);
    }
  }

  onClose(evt: any): any {
    this.close.emit(evt);
  }

}
