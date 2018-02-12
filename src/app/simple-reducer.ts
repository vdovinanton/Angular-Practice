import { Action } from '@ngrx/store';

export function simpleReducer(state: string = 'HW', action: Action) {
  console.log(state, action);

  switch (action.type)
  {
    case 'SPANISH': return state = 'hola';
    case 'FRENCH': return state = 'bonjour';

    default: return state;
  }
}