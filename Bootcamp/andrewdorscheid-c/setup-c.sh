#!/bin/bash

# This script assumes the student's repo has been cloned manually. The student 
# should have logged onto BitBucket.org, found their repo and cloned it. During that process,
# any issues with credentials (such as logging on with a Google-Id) would have been resolved.

# Change this to match your repository root
readonly TEAM_REPO="https://bitbucket.org/te-cle-cohort-16"

# Prompt the user for name and email for local git configuration
echo
read -r -p "Enter your name (First Last)? " name
read -r -p "Enter your email? " email

echo
echo "Setting Up Global Configuration Settings"

git config --global user.name "${name}"
git config --global user.email "${email}"

echo "Setting up Git Editors and Tools..."

git config --global core.editor "code -w -n"

#config VSCode as the diff tool
# git config --global diff.tool code
# git config --global difftool.code.cmd "code -w -d \$LOCAL \$REMOTE"

# To remove those settings, use these lines:
#     git config --global --unset diff.tool
#     git config --global --unset difftool.code.cmd

# config Visual Studio as the diff tool
# git config --global diff.tool vsdiffmerge
# git config --global difftool.vsdiffmerge.cmd "C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community\\Common7\\IDE\\CommonExtensions\\Microsoft\\TeamFoundation\\Team Explorer\\vsDiffMerge.exe\" \"$LOCAL\" \"$REMOTE\" //t

echo
echo "Configuring Upstream..."

git remote add upstream "${TEAM_REPO}/c-main"
git config branch.main.mergeOptions "--no-edit"

echo "Done."