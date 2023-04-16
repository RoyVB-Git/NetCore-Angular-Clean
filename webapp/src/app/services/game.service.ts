import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Game } from '../models/game';
import { environment } from '../../environments/environment';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private readonly endpoint = environment.apiUrl;
  private readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  private currentGameSubject = new BehaviorSubject<Game | null>(null);
  public currentGame = this.currentGameSubject.asObservable();

  private currentGameListSubject = new BehaviorSubject<Game[] | null>(null);
  public currentGameList = this.currentGameListSubject.asObservable();

  constructor(private http: HttpClient) { }

  public getGameById(gameId: number) {
    const observer = {
      next: (game: Game) => {
        console.log('Get game by ID: ', game);
        this.currentGameSubject.next(game);
      },
      error: (err: any) => {
        console.error(err);
      },
      complete: () => {},
    };
    this.getById(gameId).subscribe(observer);
  }

  public getAllGames() {
    const observer = {
      next: (games: Game[]) => {
        console.log('Get all games: ', games);
        this.currentGameListSubject.next(games);
      },
      error: (err: any) => {
        console.error(err);
      },
      complete: () => {},
    };
    this.getAll().subscribe(observer);
  }

  private getById(id: Number) {
    return this.http.get<Game>(
      this.endpoint + 'Game/GetById/' + id,
      this.httpOptions
    );
  }

  private getAll() {
    return this.http.get<Game[]>(this.endpoint + 'Game/GetAll', this.httpOptions);
  }
}
