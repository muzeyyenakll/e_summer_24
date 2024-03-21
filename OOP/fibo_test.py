from datetime import datetime

def fibo_i(n):
    '''Genarates Fibonacci numbers
    Iterative version'''
    fibs = [0, 1,1,]
    a = 1
    b = 1
    for i in range(3, n+1):
        f = a+b
        b = a 
        a = f
        fibs.append(f)
    return fibs

def fbc(n):
  if n<=1:
    return n
  else:
    return fbc(n-1)+fbc(n-2)
 
def fbc_list(n):
  f_list=[]
  for i in range(n+1):
    f_list.append(fbc(i))
  return f_list


# f_list_i = fibo_i(10)
# print(f_list_i)
    
# f_list_r = fbc_list(10)
# print(f_list_r)

# def comparison(n):
#     print(fibo_i(n), fbc_list(n))

before = datetime.now()
print(fibo_i(40))
after = datetime.now()
print(after-before)

#-------------------------

before = datetime.now()
print(fbc_list(30))
after = datetime.now()
print(after-before)




