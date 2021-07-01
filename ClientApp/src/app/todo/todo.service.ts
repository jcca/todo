import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  baseURL: string;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
   }

  getAllData(apiItem: string): any {
    return this.http.get(`${this.baseURL}${apiItem}`);
  }
  getOneData(apiItem: string, id: number) {
    return this.http.get(`${this.baseURL}${apiItem}/${id}`)
  }
  saveData(apiItem: string, data: any) {
    return this.http.post(`${this.baseURL}${apiItem}`, data);
  }
  updateData(apiItem: string, data: any, id: number) {
    return this.http.put(`${this.baseURL}${apiItem}/${id}`, data);
  }
  deleteData(apiItem: string, id: number) {
    return this.http.delete(`${this.baseURL}${apiItem}/${id}`);
  }
}

