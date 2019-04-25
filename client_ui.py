# -- coding: utf-8 --
import os
import socket
import sys

def File_Transfer(file_path, file_extension):
    # 연결할 서버의 네트워크 정보 정의
    TCP_IP = 'localhost'
    TCP_PORT = 9999
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as clientSocket:
        clientSocket.connect((TCP_IP, TCP_PORT)) # 소켓을 서버에 지정된 포트로 연결
        clientSocket.send(file_extension.encode('utf-8'))
        with open(file_path, 'rb') as file: # 파일 오픈
            data = file.read(1024) # 첫 1024 바이트를 읽음
            while data:
                clientSocket.send(data)
                data = file.read(1024)
        clientSocket.shutdown(socket.SHUT_WR)
        # 서버로 부터 결과를 받음
        result = (clientSocket.recv(30)).decode('utf-8')
        print(result)

if __name__ == '__main__':
    temp_path = 'C:/C#/NP/image'
    if os.path.exists('C:/C#/NP/image'):
        for file_name in os.listdir(temp_path):
            file_path = os.path.join(temp_path, file_name).replace('\\', '/')
            file_extension = os.path.splitext(file_path)[1] # 확장자 추출 
            # 파일 전송하는 부분
            File_Transfer(file_path, file_extension)


