# -- coding: utf-8 --
import os
import socket

def File_Transfer(file_path, file_extension):
    # 연결할 서버의 네트워크 정보 정의
    TCP_IP = 'localhost'
    TCP_PORT = 9999
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as clientSocket:
        clientSocket.connect((TCP_IP, TCP_PORT)) # 소켓을 서버에 지정된 포트로 연결
        clientSocket.send(file_extension.encode('utf-8'))
        with open(file_path, 'rb') as file: # 파일 오픈
            print('[1] 파일 전송을 수행합니다. : ', file_path)
            data = file.read(1024) # 첫 1024 바이트를 읽음
            while data:
                clientSocket.send(data)
                data = file.read(1024)
        clientSocket.shutdown(socket.SHUT_WR)
        # 서버로 부터 결과를 받음
        result = (clientSocket.recv(30)).decode('utf-8')
        print('[2] 서버에서 추론한 결과 : ', result)

if __name__ == '__main__':
    # 어떤 파일을 전송할 지 사용자가 선택함
    file_name = input("전송하고자 하는 파일명 : ") # 사용자로부터 전송할 파일을 입력 받음
    file_path = os.path.join('sample/', file_name) # 온전한 파일 경로를 만듬

    if not os.path.exists(file_path): # 사용자가 입력한 파일경로에 파일이 존재하지 않으면,
        print('[!] 입력하신 파일은 존재하지 않습니다. (파일명 : ' + file_name + ')') # 경고 메시지 출력
        exit() # 프로그램 종료

    file_extension = os.path.splitext(file_path)[1] # 확장자 추출
    # 파일 전송
    File_Transfer(file_path, file_extension)


