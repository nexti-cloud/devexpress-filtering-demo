/* tslint:disable */
/* eslint-disable */
import { UserResponse } from '../models/user-response';
export interface UserResponseFilteredResult {
  data: Array<UserResponse>;
  groupCount?: number;
  summary: Array<any>;
  totalCount?: number;
}
