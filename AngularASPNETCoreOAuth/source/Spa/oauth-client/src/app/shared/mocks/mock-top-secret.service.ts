import { of } from 'rxjs';


export class MockFridgeTycoonService { 
    fetchFridgeTycoonData(token: string) {    
        return of([1,2,3,4,5]); 
      }   
}