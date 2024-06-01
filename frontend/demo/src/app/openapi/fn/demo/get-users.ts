/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';

import { UserResponseFilteredResult } from '../../models/user-response-filtered-result';

export interface GetUsers$Params {
  skip?: string;
  take?: string;
  requireTotalCount?: string;
  requireGroupCount?: string;
  sort?: string;
  filter?: string;
  totalSummary?: string;
  group?: string;
  groupSummary?: string;
}

export function getUsers(http: HttpClient, rootUrl: string, params?: GetUsers$Params, context?: HttpContext): Observable<StrictHttpResponse<UserResponseFilteredResult>> {
  const rb = new RequestBuilder(rootUrl, getUsers.PATH, 'get');
  if (params) {
    rb.query('skip', params.skip, {"style":"form"});
    rb.query('take', params.take, {"style":"form"});
    rb.query('requireTotalCount', params.requireTotalCount, {"style":"form"});
    rb.query('requireGroupCount', params.requireGroupCount, {"style":"form"});
    rb.query('sort', params.sort, {"style":"form"});
    rb.query('filter', params.filter, {"style":"form"});
    rb.query('totalSummary', params.totalSummary, {"style":"form"});
    rb.query('group', params.group, {"style":"form"});
    rb.query('groupSummary', params.groupSummary, {"style":"form"});
  }

  return http.request(
    rb.build({ responseType: 'json', accept: 'application/json', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return r as StrictHttpResponse<UserResponseFilteredResult>;
    })
  );
}

getUsers.PATH = '/api/users';
