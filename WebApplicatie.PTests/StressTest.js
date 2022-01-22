import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    //Een test die steeds meer gebruikers het website laat bezoeken en acties voeren in batch
  stages: [
    { duration: '5s', target: 100 }, // below normal load
    { duration: '8s', target: 100 },
    { duration: '5s', target: 200 }, // normal load
    { duration: '8s', target: 200 },
    { duration: '7s', target: 300 }, // around the breaking point
    { duration: '5s', target: 300 },
    { duration: '4s', target: 400 }, // beyond the breaking point
    { duration: '8s', target: 400 },
    { duration: '12s', target: 0 }, // scale down. Recovery stage.
  ],
};

export default function () {
  const BASE_URL = 'https://hhs-zmdh.azurewebsites.net'; // make sure this is not production

  const responses = http.batch([
    ['GET', `${BASE_URL}/Orthopedagoog/Laura`],
    ['GET', `${BASE_URL}/Orthopedagoog/Takezo`],
    ['GET', `${BASE_URL}/Orthopedagoog/Jan`],
    ['GET', `${BASE_URL}/Orthopedagoog/Dagmar`],
  ]);

  sleep(1);
}
