program main
  implicit none
  print *, "################## Sample Data ##################"
  call runner("../input-1.sample.txt", 3)
  print *, "################## Real Data ##################"
  call runner("../input-1.txt", 4)
  print *, "###############################################"
  
end program main

subroutine runner(file, amount)
  implicit none
  character (len=60) :: file
  integer :: amount, i, t, d, x, run, race, result
  ! This is a comment line, it is ignored by the compiler
  result = 1
  do i = 1, amount
    !print *, 'Running read file'
    if(amount == 3) then
      call readfile1(file, i, t, d)
    end if
    if(amount == 4) then
      call readfile2(file, i, t, d)
    end if

    write (*,'(A, I0, A, I0)') 'Running t=', t,', d=', d
    run = 0
    race = 0
    do x = 0, t
      run = (x * (t - x))
      if(run > d) then
        write (*,'(A, I0)') 'Found larger then distance: ', run
        race = race + 1
      end if
      
    end do
    result = result * race
    write (*,'(A, I0)') 'Races won: ', race

  end do
  write (*, '(A, I0)') 'Result: ', result
end subroutine runner

subroutine  readfile1(file, i, t, d)
  implicit none
  integer :: i, t, d
  character(len=60) :: file
  character (len=100) :: line
  integer :: m(4), ti(4)

  open (unit = 1, file = file, status = 'old')
  rewind(1)
  read(1,*) line, ti(1), ti(2), ti(3)
  read(1,*) line, m(1), m(2), m(3)
  t = ti(i)
  d = m(i)
end subroutine readfile1

subroutine  readfile2(file, i, t, d)
  implicit none
  integer :: i, t, d
  character(len=60) :: file
  character (len=100) :: line
  integer :: di(5), ti(5)

  open (unit = 1, file = file, status = 'old')
  rewind(1)
  read(1,*) line, ti(1), ti(2), ti(3), ti(4)
  read(1,*) line, di(1), di(2), di(3), di(4)
  t = ti(i)
  d = di(i)
end subroutine readfile2