import { Component, OnInit } from '@angular/core';
import { Hero } from '../hero';
import { HEROES } from '../mock-heroes';
import { HeroService } from '../hero.service';

@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})

export class HeroesComponent implements OnInit {
  heroes: Hero[];

  constructor(private heroService: HeroService) { }

  ngOnInit() {
    this.getHeroes();

    //this.save();
    //this.add('qwert');
  }

  getHeroes(): void {
    this.heroService.getHeros().subscribe(heroes => this.heroes = heroes);
  }

  add(name: string): void {
    name = name.trim();
    if (!name) { return; }

    this.heroService.addHero({ Name: name, Id: 0 } as Hero )
      .subscribe(hero => {
        this.heroes.push(hero);
      });
  }

  //save(): void {
  //  var hero = { Id: 11, Name: 'Mr. Nice 2' };
  //  this.heroService.updateHero(hero)
  //    .subscribe(() => console.log('saved'));
  //}

  delete(hero: Hero): void {
    this.heroes = this.heroes.filter(h => h !== hero);
    this.heroService.deleteHero(hero).subscribe();
  }

}
