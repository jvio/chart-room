/**
 * Swagger Chat-Room
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0.0
 *
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

export interface User {
  userId?: number;
  username: string;
  firstName?: string;
  lastName?: string;
  email?: string;
  password?: string;
  phone?: string;
  isDoctor?: boolean;
  age?: number;
  blood?: string;
  /**
   * User Status
   */
  userStatus?: User.UserStatusEnum;
}
export namespace User {
  export type UserStatusEnum = 'online' | 'offline';
  export const UserStatusEnum = {
    Online: 'online' as UserStatusEnum,
    Offline: 'offline' as UserStatusEnum
  };
}
