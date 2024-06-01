import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import {provideHttpClient} from "@angular/common/http";
import {ApiConfiguration} from "./openapi/api-configuration";

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    { provide: ApiConfiguration, useValue: { rootUrl: 'http://localhost:5246' } }
  ]
};
