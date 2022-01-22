import http from 'k6/http';
import { sleep, check } from 'k6';

//Hier gebruiken wij het programma k6 om de performance van onze website te testen.
export default function () {
 let res = http.get('https://hhs-zmdh.azurewebsites.net/');
 check(res, {
   'is status 200': (r) => r.status === 200,
   //checkt of het website een bepaalde tekst bevat
   'Home pagina ZMDH': (r) => r.body.includes("Praktijk voor Orthopedagogiek & Psychologie Zorg Maatschap Den Haag (ZMDH)")
 });
  sleep(1);
}
