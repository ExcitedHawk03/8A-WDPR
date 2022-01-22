import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  stages: [
    { duration: '15s', target: 100 }, 
    { duration: '30s', target: 100 }, 
    { duration: '15s', target: 0 }, 
  ],
  thresholds: {
    'http_req_duration': ['p(99)<150'], // 99% of requests must complete below 150ms
  },
};

export default function () {
    let res = http.get('https://hhs-zmdh.azurewebsites.net/')
check(res, {
    'is status 200': (r) => r.status === 200
})
sleep(Math.random() * 5);
};


