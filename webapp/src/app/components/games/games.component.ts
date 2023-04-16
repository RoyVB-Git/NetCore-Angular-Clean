import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Game } from './../../models/game';
import { GameService } from './../../services/game.service';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.scss']
})
export class GamesComponent implements OnInit {
  public game!: Observable<Game | null>;
  public games!: Observable<Game[] | null>;

  public displayedColumns: string[] = ['id', 'name', 'description'];
  public dataSource: any;

  constructor(private gameService: GameService) {
  }

  ngOnInit(): void {
    this.getGameById();
    this.getAllGames();
  }

  private getGameById(): void {
    this.gameService.getGameById(1);
    this.game = this.gameService.currentGame;
  }

  private getAllGames(): void {
    this.gameService.getAllGames();
    this.games = this.gameService.currentGameList;
    this.dataSource = this.games;
  }
}
