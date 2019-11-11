import { Component, Input, OnInit } from '@angular/core';
import { User } from '../../../api';

@Component({
  selector: 'app-avatar',
  templateUrl: './avatar.component.html',
  styleUrls: ['./avatar.component.scss']
})
export class AvatarComponent implements OnInit {
  @Input()
  user: User;

  constructor() {}

  ngOnInit() {}
}
