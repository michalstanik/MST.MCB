import { Component, OnInit, Input } from '@angular/core';
import { Stop } from 'src/app/core/model/Stop/stop-model';

@Component({
  selector: 'app-stops-list',
  templateUrl: './stops-list.component.html',
  styleUrls: ['./stops-list.component.scss']
})
export class StopsListComponent implements OnInit {

  @Input() stops: Stop[];
  constructor() { }

  ngOnInit() {
  }

}
