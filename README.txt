Mommy Project ReadMe (Unity Pro Required?)

+++Git++++
+setup
	git init
	git clone https://github.com/Tarwine/Mommy.git
	cd Mommy
	git remote add origin https://github.com/Tarwine/Mommy.git
	git fetch origin

+creating a branch
	git checkout -b <branchName>
	git push --set-upstream origin <branchName>

+switching branches
	git chechout <newBranchName>
	
+pushing to current branch
	git status
	git commit --all -m"<message>"
	git push origin <branchName>
	
+pulling from master
	git fetch origin
	git merge origin/master

+pulling from branch
	git fetch <branchName>
	git merge origin/<branchName>

+deleting a branch locally
	git branch -d <branchName>
	
+refreshing remote branches
	git remote prune origin



+Game Keyboard Commands
 - 'O' -- Enable Oculus
 - 'E' -- Interact
 - '(Hold)RClick' -- Activate flashlight controls
 - 'W, A, S, D' -- Movement