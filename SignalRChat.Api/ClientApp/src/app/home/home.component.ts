import { Component, OnInit } from '@angular/core';
import { MessageDto } from '../Dto/MessageDto';
import { ChatService } from '../services/Chat.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.scss']
})
export class HomeComponent implements OnInit  {

  msgDto: MessageDto = new MessageDto();
  msgInboxArray: MessageDto[] = [];

  constructor(private chatService: ChatService) {}
  ngOnInit(): void {
    debugger;
    this.chatService.retrieveMappedObject().subscribe( (receivedObj: MessageDto) => { debugger; this.addToInbox(receivedObj);});  // calls the service method to get the new messages sent
                                                     
  }
  send(): void {
    if(this.msgDto) {
      if(this.msgDto.user.length == 0 || this.msgDto.user.length == 0){
        window.alert("Both fields are required.");
        return;
      } else {
        this.chatService.broadcastMessage(this.msgDto);                   // Send the message via a service
      }
    }
  }

  addToInbox(obj: MessageDto) {
    let newObj = new MessageDto();
    newObj.user = obj.user;
    newObj.message = obj.message;
    this.msgInboxArray.push(newObj);

  }

}
