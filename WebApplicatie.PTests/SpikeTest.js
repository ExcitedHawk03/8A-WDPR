import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
  stages: [
    { duration: '5s', target: 100 }, // below normal load
    { duration: '10s', target: 100 },
    { duration: '3s', target: 1400 }, // spike to 1400 users
    { duration: '30s', target: 1400 }, // stay at 1400 for 3 minutes
    { duration: '20s', target: 100 }, // scale down. Recovery stage.
    { duration: '15s', target: 100 },
    { duration: '10s', target: 0 },
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
