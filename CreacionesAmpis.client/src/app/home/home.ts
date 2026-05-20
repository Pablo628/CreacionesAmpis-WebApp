import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { pruebaService } from '../../services/prueba.service';
import { IGetUsers } from '../../interfaces/users';

@Component({
  selector: 'app-home',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  constructor(private pruebaService: pruebaService) {}
  data: IGetUsers[] = [];

  ngOnInit() {
    this.pruebaService.getUser().subscribe({
      next: (response) => {
        this.data = response;
        console.log(this.data);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
}
