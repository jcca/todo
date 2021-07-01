import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TodoService } from './todo.service';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.scss'],
})
export class TodoComponent implements OnInit {
  lists: Observable<any>;
  //lists: any;
  cambio = "Nuevo to do";
  data = {
    nombre: "",
    descripcion: ""
  };

  constructor(private todoApi: TodoService) {}

  ngOnInit(): void {
    this.getAllTodo();
  }

  addOneTodo(todo: any) {
    if (todo.id === undefined) this.todoApi.saveData('todos', todo).subscribe(() => {
      this.getAllTodo();
    });
    else this.updateOneTodo(todo);
    this.data = {
      nombre: "",
      descripcion: ""
    }
    this.cambio = "Nuevo to do";
  }

  updateOneTodo(todo: any) {

    let idTodo = todo.id;
    this.todoApi.updateData('todos', todo, idTodo).subscribe(() => {
      this.getAllTodo();
    });
  }
  update(todo: any) {
    this.cambio = "Actulaizar to do";
    this.data = Object.assign({}, todo);
  }

  getAllTodo() {
    this.todoApi.getAllData('todos').subscribe(
      (data: any) => {
        this.lists = data;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }

  deleteOneTodo(id: any) {
    this.todoApi.deleteData('todos', id).subscribe(() => {
      this.getAllTodo();
    });
  }
}
