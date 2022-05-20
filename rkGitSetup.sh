# Copy good .gitignore and .gitattributes
#cp GitIgnore-good.txt $DEST/.gitignore
#cp GitAttributes-good.txt $DEST/.GitAttributes

git init

git lfs install
# git lfs update --force

git submodule add https://bitbucket.org/TeaClipper/tcg.hackspace.unity-git

# Already in good gitignore
# ./tcg.hackspace.unity-git/scripts/ignore-dir-meta-files.sh

# Actually only really like the pre-commit one (the other two just remove empty directories after pulls etc)
./tcg.hackspace.unity-git/scripts/install-hooks.sh

